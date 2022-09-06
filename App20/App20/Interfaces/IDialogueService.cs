using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App20.Interfaces
{
    public interface IDialogueService
    {
        void DialogueBox(string title, string message, string buttonText);
    }
}
