using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Server
{
    public class Queue
    {
        private List<string> _workerIds;

        public Queue(string name, int maxWorkers)
        {
            this.Name = name;
            this.MaxWokers = maxWorkers;
            _workerIds = new List<string>();
        }

        public string Name { get; private set; }

        public int MaxWokers { get; set; }

        public void AddWorker(string id)
        {
            if(MaxWokers > _workerIds.Count)
            {
                _workerIds.Add(id);
            }
        }
    }
}
