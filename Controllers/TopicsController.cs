using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoard.Controllers
{
    public class TopicsController : ApiController
    {
        private IMessageBoardRepository _repo;
        public TopicsController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Topic> Get(bool includeReplies = false)
        {
             if (includeReplies)
            {
                return _repo.GetTopicsIncludingReplies().OrderByDescending(t => t.Created).Take(50).ToList();
            }
            else
            {
                return _repo.GetTopics().OrderByDescending(t => t.Created).Take(50).ToList();
            }
        }

        public HttpResponseMessage Post([FromBody]Topic topic)
        {
            if (topic.Created == default(DateTime))
                topic.Created = DateTime.UtcNow;
            if (_repo.AddTopic(topic) && _repo.Save())
            {
                return Request.CreateResponse(HttpStatusCode.Created, topic);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
