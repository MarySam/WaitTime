﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Bot.Builder.Calling.ObjectModel.Contracts
{
    /// <summary>
    /// This is the action which customers can specify to indicate that the server call agent should play/tts out prompt(s).
    /// </summary>
    [JsonObject(MemberSerialization.OptOut)]
    public class PlayPrompt : ActionBase
    {
        /// <summary>
        /// List of prompts to play out
        /// </summary>
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<Prompt> Prompts { get; set; }

        public PlayPrompt()
        {
            this.Action = ValidActions.PlayPromptAction;
        }

        public override void Validate()
        {
            base.Validate();
            Prompt.Validate(this.Prompts);
        }
    }
}
