using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerV2._0
{
    class CommandSelector
    {
        // Данный класс служит определения введенной пользователем команды.
        public Commands Select(string s)
        {
            if (s.Contains("cd"))
                return Commands.SWITCH;
            else if (s.Contains("delete -f"))
                return Commands.DELETE_FILE;
            else if (s.Contains("delete -d"))
                return Commands.DELETE_DIR;
            else if (s.Contains("copy -f"))
                return Commands.COPY_FILE;
            else if (s.Contains("copy -d"))
                return Commands.COPY_DIR;
            else if (s.Contains("info -f"))
                return Commands.GET_FILE_INFO;
            else if (s.Contains("info -d"))
                return Commands.GET_DIR_INFO;
            else if (s.Contains("cmd -list"))
                return Commands.COMMANDS_LIST;
            else if (s.Contains("next"))
                return Commands.NEXT;
            else if (s.Contains("prev"))
                return Commands.PREV;
            else if (s.Contains("cmd list"))
                return Commands.COMMANDS_LIST; 
            else
                throw new Exception("Command was not recognized!"); 
        }
    }
}
