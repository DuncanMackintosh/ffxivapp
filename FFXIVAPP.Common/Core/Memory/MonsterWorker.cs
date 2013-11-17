﻿// FFXIVAPP.Common
// MonsterWorker.cs
// 
// © 2013 Ryan Wilson

#region Usings

#endregion

namespace FFXIVAPP.Common.Core.Memory
{
    // internal, not accessible by plugins
    public class MonsterWorker : IMonsterWorker
    {
        public delegate void NewEntryEventHandler(ActorEntity actorEntity);

        public event NewEntryEventHandler OnNewEntry = delegate { };

        public void RaiseEntryEvent(ActorEntity actorEntity)
        {
            OnNewEntry(actorEntity);
        }
    }
}
