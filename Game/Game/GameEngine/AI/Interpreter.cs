using System;
using System.Collections.Generic;
using Game.GameEngine.Persons;
using BBox = Game.GameEngine.HelpClasses.BoundingBox;

namespace Game.GameEngine.AI
{
    public class Interpreter
    {
        private List<MovedPerson> persons = new List<MovedPerson>();

        public void AddPerson(MovedPerson person)
        {
            persons.Add(person);
        }

        public void Update(int delta, List<BBox> items)
        {
            foreach (var item in persons)
                item.Update(delta, items);
        }
    }
}
