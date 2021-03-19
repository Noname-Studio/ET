using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;

namespace ET
{
    public class ChatUnitComponent: Entity
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private readonly Dictionary<long, ChatUnit> idUnits = new Dictionary<long, ChatUnit>();

        public override void Dispose()
        {
            if (this.IsDisposed)
            {
                return;
            }
            base.Dispose();

            foreach (ChatUnit unit in this.idUnits.Values)
            {
                unit.Dispose();
            }
            this.idUnits.Clear();
        }

        public void Add(ChatUnit unit)
        {
            this.idUnits.Add(unit.Id, unit);
            unit.Parent = this;
        }

        public ChatUnit Get(long id)
        {
            this.idUnits.TryGetValue(id, out ChatUnit unit);
            return unit;
        }

        public void Remove(long id)
        {
            ChatUnit unit;
            this.idUnits.TryGetValue(id, out unit);
            this.idUnits.Remove(id);
            unit?.Dispose();
        }

        public void RemoveNoDispose(long id)
        {
            this.idUnits.Remove(id);
        }

        public int Count
        {
            get
            {
                return this.idUnits.Count;
            }
        }

        public ChatUnit[] GetAll()
        {
            return this.idUnits.Values.ToArray();
        }
    }
}