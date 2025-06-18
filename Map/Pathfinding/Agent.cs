using System;
using System.Collections.Generic;
using Aiv.Fast2D;
using OpenTK;

namespace Pokimon
{
    class Agent
    {
        List<Node> path;
        Node current;
        Node target;

        Entity owner;

        public int X { get { return Convert.ToInt32(owner.Position.X); } }
        public int Y { get { return Convert.ToInt32(owner.Position.Y); } }
        public Node Target { get { return target; } set { target = value; } }

        Sprite pathSpr;
        protected Vector4 pathColor;

        public Agent(Entity owner)
        {
            this.owner = owner;
            target = null;

            pathSpr = new Sprite(0.25f, 0.25f);
            pathColor = new Vector4(0.9f, 0.9f, 0.0f, 1.0f);
        }


        public virtual void SetPath(List<Node> newPath)
        {
            path = newPath;

            if(target == null && path.Count > 0)
            {
                target = path[0];
                path.RemoveAt(0);
            }
            else if(path.Count > 0)
            {
                int dist = Math.Abs(path[0].X - target.X) + Math.Abs(path[0].Y - target.Y);

                if(dist > 1)
                {
                    path.Insert(0, current);
                }
            }
        }

        public void Update(float speed)
        {
            if(target != null)
            {
                Vector2 destination = new Vector2(target.X, target.Y);
                Vector2 direction = destination - owner.Position;
                float distance = direction.Length;

                if(distance < 0.1f)
                {
                    current = target;
                    owner.Position = destination;

                    if(path.Count == 0)
                    {
                        target = null;
                        owner.Velocity = Vector2.Zero;
                    }
                    else
                    {
                        target = path[0];
                        path.RemoveAt(0);
                    }
                }
                else
                {
                    owner.Position += direction.Normalized() * Game.DeltaTime * speed;
                }
            }
        }

        public void Draw()
        {
            if(path != null && path.Count > 0)
            {
                foreach(Node n in path)
                {
                    pathSpr.position = new Vector2(n.X, n.Y);
                    pathSpr.DrawColor(pathColor);
                }
            }
        }
    }
}
