﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Action
{
    /// <summary>
    /// Interface for behaviour tree nodes.
    /// </summary>
    public interface IActionNode
    {
        /// <summary>
        /// Update the time of the behaviour tree.
        /// </summary>
        ActionStatus Tick(TimeData time);
    }


    /// <summary>
    /// A behaviour tree leaf node for running an action.
    /// </summary>
    public class ActionNode : IActionNode
    {
        /// <summary>
        /// The name of the node.
        /// </summary>
        private string name;

        /// <summary>
        /// Function to invoke for the action.
        /// </summary>
        private Func<TimeData, ActionStatus> fn;
        

        public ActionNode(string name, Func<TimeData, ActionStatus> fn)
        {
            this.name=name;
            this.fn=fn;
        }

        public ActionStatus Tick(TimeData time)
        {
            return fn(time);
        }
    }
}
