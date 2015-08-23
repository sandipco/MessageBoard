using MessageBoard.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MessageBoard.Controllers
{
    public class RepliesController : ApiController
    {
        private IMessageBoardRepository _repo;
        public RepliesController(IMessageBoardRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Reply> Get(int topicId)
        {
            return _repo.GetRepliesByTopic(topicId).Take(25).ToList();
        }
        public HttpResponseMessage Post(int topicId, [FromBody]Reply reply)
        {
            try
            {
                if (reply.Created == default(DateTime))
                    reply.Created = DateTime.UtcNow;
                reply.TopicId = topicId;
                if (_repo.AddReply(reply) && _repo.Save())
                {
                    return Request.CreateResponse(HttpStatusCode.Created, reply);
                }
                else
                    throw new Exception();
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
