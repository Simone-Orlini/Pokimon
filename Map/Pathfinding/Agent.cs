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

        Vector2 direction;

        public Agent(Entity owner)
        {
            this.owner = owner;
            target = null;
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

        public Vector2 GetDirection()
        {
            return direction;
        }

        public void Update(float speed)
        {
            direction = Vector2.Zero;

            if(target != null)
            {
                Vector2 destination = new Vector2(target.X, target.Y);
                direction = destination - owner.Position;
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
    }
}
