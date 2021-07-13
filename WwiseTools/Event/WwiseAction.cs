﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WwiseTools.Properties;
using WwiseTools.Basic;

namespace WwiseTools
{
    /// <summary>
    /// Wwise事件中的Action
    /// </summary>
    public class WwiseAction : WwiseUnit
    {
        /// <summary>
        /// Action类型
        /// </summary>
        public enum ActionType { Play, Stop, StopAll, Pause, PauseAll, Resume, ResumeAll, Break, Seek, SeekAll, PostEvent }

        /// <summary>
        /// 初始化Action Type以及一个Wwise的物体应用
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="reference"></param>
        public WwiseAction(ActionType actionType, WwiseObjectRef reference) : base("", "Action")
        {
            AddProperty(new Properties.WwiseProperty("ActionType", "int16", ActionTypeCheck(actionType).ToString()));
            AddChildNode(WwiseNode.NewReferenceList(new List<IWwisePrintable>()
            {
                new WwiseNodeWithName("Reference", "Target", reference)
            }));
        }

        private int ActionTypeCheck(ActionType type)
        {
            switch (type)
            {
                case ActionType.Play:
                    return 1;
                case ActionType.Stop:
                    return 2;
                case ActionType.StopAll:
                    return 3;
                case ActionType.Pause:
                    return 4;
                case ActionType.PauseAll:
                    return 5;
                case ActionType.Resume:
                    return 6;
                case ActionType.ResumeAll:
                    return 7;
                case ActionType.Break:
                    return 8;
                case ActionType.Seek:
                    return 9;
                case ActionType.SeekAll:
                    return 10;
                case ActionType.PostEvent:
                    return 11;
                default:
                    return 1;
            }
        }
    }
}
