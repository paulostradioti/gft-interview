using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Utilities;

namespace Domain.Entites
{
    public class Order
    {
        private UserInputParser InputParser
        {
            get { return _userInputParser; }
        }

        public List<Dish> Selections;

        public TimeOfDay TimeOfDay; 

        private UserInputParser _userInputParser;


        public Order(string userInput)
        {
            _userInputParser = new UserInputParser(userInput);
            Selections = new List<Dish>();

            ProcessOrder();
        }

        private void ProcessOrder()
        {
            TimeOfDay = _userInputParser.GetTimeOfDay();
            Selections = _userInputParser.GetSelectionList();
        }
    }
}
