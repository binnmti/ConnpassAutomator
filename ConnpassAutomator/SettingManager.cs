using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnpassAutomator
{
    /// <summary>
    /// セーブ、ロードの責務を持つ
    /// </summary>
    public class SettingManager
    {
        public static ConnpassWillbeRenamed Load()
        {
            return new ConnpassWillbeRenamed();
        }

        public static void Save(ConnpassWillbeRenamed connpassWillbeRenamed)
        {
        }
    }
}
