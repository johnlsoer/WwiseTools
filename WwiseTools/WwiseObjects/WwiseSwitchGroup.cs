﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WwiseTools.Utils;

namespace WwiseTools.Objects
{
    public class WwiseSwitchGroup : WwiseObject
    {
        public WwiseSwitchGroup(string name, string parent_path = @"\Switches\Default Work Unit") : base(name, "", ObjectType.SwitchGroup.ToString())
        {
            var tempObj = WwiseUtility.CreateObject(name, ObjectType.SwitchGroup, parent_path);
            ID = tempObj.ID;
            Name = tempObj.Name;
        }

        public WwiseSwitchGroup(WwiseObject @object) : base ("", "", "")
        {
            ID = @object.ID;
            Name = @object.Name;
            Type = @object.Type;
        }


        /// <summary>
        /// 返回该Switch Goup中的所有Switch
        /// </summary>
        /// <returns></returns>
        public List<WwiseObject> GetSwitches()
        {
            List<WwiseObject> temp = WwiseUtility.GetWwiseObjectsOfType(ObjectType.Switch.ToString());
            List<WwiseObject> result = new List<WwiseObject>();
            foreach (var obj in temp)
            {
                if (obj.Path.Contains(Path))
                {
                    result.Add(obj);
                }
            }

            return result;

        }
    }
}
