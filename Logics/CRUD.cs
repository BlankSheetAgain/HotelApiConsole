using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_API
{
    class CRUD<T>
    {
        private string _path;
        private List<T> _collection;
        public Task <List<T>> Collection { get => ReadAsync(); }
        private DateTime _lastAccess;
        public CRUD (string path)
        {
            this._path = path;
            _collection = new();
        }
        private async Task FileSaveAsync()
        {
                using StreamWriter writer = new(_path, false);
                foreach (var el in _collection)
                {
                    await writer.WriteLineAsync(JsonConvert.SerializeObject(el)).ConfigureAwait(false);
                }
                _lastAccess = DateTime.UtcNow;
        }

        private async Task<List<T>> ReadAsync()
        {
            if (_lastAccess < File.GetLastWriteTimeUtc(_path))
            {
                using StreamReader reader = new(_path);
                    List<T> collection = new();
                    while (!reader.EndOfStream)
                    {
                        string temp = await reader.ReadLineAsync();
                        T obj = JsonConvert.DeserializeObject<T>(temp);
                        collection.Add(obj);

                    }
                    _lastAccess = DateTime.UtcNow;
                    this._collection = collection;
                }
            return this._collection;
        }
        public async Task AddAsync(T obj)
        {
            using StreamWriter writer = new(_path, true);
            await writer.WriteLineAsync(JsonConvert.SerializeObject(obj)).ConfigureAwait(false);
            _lastAccess = DateTime.UtcNow;
        }
        public async Task DeleteAsync(int index)
        {
            _collection = await ReadAsync();
            if (_collection == null)
            {
                return;            }
            _collection.RemoveAt(index-1);
            await FileSaveAsync().ConfigureAwait(false);
        }

        public async Task UpdateAsync(int index, T obj)
        {
            _collection = await ReadAsync().ConfigureAwait(false);
            if (_collection==null)
            {
                return;
            }
            _collection[index] = obj;
            await FileSaveAsync().ConfigureAwait(false);
        }
    }
}
