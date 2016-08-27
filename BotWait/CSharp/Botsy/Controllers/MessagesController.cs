using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Bot.Connector;
using Newtonsoft.Json;

namespace Botsy
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        /// <summary>
        /// POST: api/Messages
        /// Receive a message from a user and reply to it
        /// </summary>
        public async Task<HttpResponseMessage> Post([FromBody]Activity activity)
        {
            if (activity.Type == ActivityTypes.Message)
            {
                LuisInfo luisInfo = await LuisMovieClient.ParseUserInput(activity.Text);

                string responseMessage;
                if (luisInfo.intents.Count() > 0)
                {
                    //intents[0] is the highest probability of intent.
                    switch (luisInfo.intents[0].intent)
                    {
                        case "GetMovieYear":
                            if (luisInfo.entities.Count() > 0)
                            {
                                responseMessage = await MovieUtilities.GetMovieYear(luisInfo.entities[0].entity);
                            }
                            else
                            {
                                responseMessage = "Sorry, I don't understand which movie you want.";
                            }
                            break;
                        case "GetMovieDirector":
                            if (luisInfo.entities.Count() > 0)
                            {
                                responseMessage = await MovieUtilities.GetMovieDirector(luisInfo.entities[0].entity);
                            }
                            else
                            {
                                responseMessage = "Sorry, I don't understand which movie you want.";
                            }
                            break;
                        default:
                            responseMessage = "Sorry, I don't know how to " + luisInfo.intents[0].intent;
                            break;
                    }
                }
                else
                {
                    responseMessage = "Sorry, I'm not sure what you want.";
                }

                ConnectorClient connector = new ConnectorClient(new Uri(activity.ServiceUrl));
                
                // return our reply to the user
                Activity reply = activity.CreateReply(responseMessage);
                await connector.Conversations.ReplyToActivityAsync(reply);
            }
            else
            {
                HandleSystemMessage(activity);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK);
            return response;
        }
        private Activity HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                // Handle conversation state changes, like members being added and removed
                // Use Activity.MembersAdded and Activity.MembersRemoved and Activity.Action for info
                // Not available in all channels
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }
            return null;
        }
    }
}