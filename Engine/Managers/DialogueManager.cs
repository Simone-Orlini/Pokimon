using System;
using System.Collections.Generic;
using System.IO;
using OpenTK;

namespace Pokimon
{
    public static class DialogueManager
    {
        static TextObject dialogueHeader;
        static TextObject dialogueText;
        static InteractionBar interactionBar;
        static Dictionary<string, string> dialogues;
        static PlayScene currentScene;

        static DialogueManager()
        {
            interactionBar = new InteractionBar();
            dialogueHeader = new TextObject(Vector2.Zero, "", horizontalSpacing : 0.1f);
            dialogueText = new TextObject(Vector2.Zero, "", horizontalSpacing : 0.1f);
            dialogues = new Dictionary<string, string>();
        }

        public static void Init(PlayScene scene)
        {
            currentScene = scene;

            if (!DrawManager.Contains(interactionBar, DrawLayer.UI))
            {
                DrawManager.AddItem(interactionBar);
            }

            using (StreamReader reader = new StreamReader("dialogues.txt"))
            {
                if(scene.Npcs.Count > 0)
                {
                    List<string> fullFile = ReadAllfile(reader);

                    if (fullFile == null || fullFile.Count <= 0)
                    {
                        Console.WriteLine("File is empty");
                        return;
                    }
                    
                    foreach(Npc npc in scene.Npcs)
                    {
                        for(int i = 0; i < fullFile.Count; i++)
                        {
                            if(fullFile[i] == npc.Name)
                            {
                                dialogues[npc.Name] = fullFile[i + 1];
                            }
                        }
                    }
                }
            }
        }

        public static void StartDialogue(string npcName)
        {
            if (dialogues.ContainsKey(npcName))
            {
                // Set camera position
                if (!currentScene.FixedCamera)
                {
                    currentScene.Camera.position = currentScene.PlayerPosition;
                }

                // Activate the black bar
                interactionBar.Activate();

                // Create the header
                dialogueHeader.Position = new Vector2(currentScene.Camera.position.X - (Game.ScreenCenterX - 0.5f), currentScene.Camera.position.Y + (Game.ScreenCenterY - interactionBar.HalfHeight * 2));
                dialogueHeader.ClearText();
                dialogueHeader.SetText(npcName);
                dialogueHeader.IsActive = true;

                // Create the text
                dialogueText.Position = dialogueHeader.Position + new Vector2(0, 1);
                dialogueText.ClearText();
                dialogueText.SetText(dialogues[npcName]);
                dialogueText.IsActive = true;
            }
        }

        public static void EndDialogue()
        {
            interactionBar.Deactivate();
            dialogueHeader.IsActive = false;
            dialogueText.IsActive = false;
            dialogueHeader.ClearText();
            dialogueText.ClearText();
        }

        private static List<string> ReadAllfile(StreamReader reader)
        {
            List<string> lines = new List<string>();
            string line;
            while((line = reader.ReadLine()) != null) // thanks https://stackoverflow.com/questions/13312906/readalllines-for-a-stream-object
            {
                lines.Add(line);
            }

            return lines;
        }
    }
}
