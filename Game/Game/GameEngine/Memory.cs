using System.Collections.Generic;
using Game.GameEngine.Bullets;
using Game.GameEngine.Persons;

namespace Game.GameEngine
{
    public class Memory
    {
        public static List<int> PersonsId = new List<int>();
        public static List<MovedPerson> Persons = new List<MovedPerson>();
        public static List<Bullet> Bullets = new List<Bullet>();

        public static void Update()
        {
            for (int i = 0; i < Persons.Count; i++)
            {
                foreach (var index in PersonsId)
                    if (Persons[i].ID == index)
                    {
                        if (Persons[i].Shoot())
                        {
                            Persons.Remove(Persons[i]);
                            i--;
                        }
                    }
            }
            PersonsId.Clear();
        }
    }
}
