using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangfire.Server
{
    public class Queue
    {
        private string _queue;
        private List<string> _workerIds;

        public Queue(string name, int maxWorkers)
        {
            this.Name = name;
            this.MaxWokers = maxWorkers;
            _workerIds = new List<string>();
        }

        public string Name
        {
            get { return _queue; }
            private set
            {
                ValidateName("Name", value);
                _queue = value;
            }
        }

        public int MaxWokers { get; set; }

        public void AddWorker(string id)
        {
            if(!HasMaxWorkers())
            {
                _workerIds.Add(id);
            }
        }

        public bool HasMaxWorkers()
        {
            return _workerIds.Count >= MaxWokers;
        }

        private void ValidateName(string parameterName, string value)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(parameterName);
            }

            if (!Regex.IsMatch(value, @"^[a-z0-9_]+$"))
            {
                throw new ArgumentException(
                    String.Format(
                        "The queue name must consist of lowercase letters, digits and underscore characters only. Given: '{0}'.",
                        value),
                    parameterName);
            }
        }
    }
}
