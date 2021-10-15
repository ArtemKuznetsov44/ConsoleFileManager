using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileManagerV2._0
{
    // Перечисление всех возможных комманд для построения дальнейшей логики приложения.
    enum Commands
    {
        SWITCH,
        DELETE_FILE,
        DELETE_DIR,
        COPY_FILE,
        COPY_DIR,
        GET_FILE_INFO,
        GET_DIR_INFO,
        COMMANDS_LIST, 
        NEXT, 
        PREV
    }
}
