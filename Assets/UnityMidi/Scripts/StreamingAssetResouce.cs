using UnityEngine;
using System.IO;
using AudioSynthesis;

namespace UnityMidi
{
    [System.Serializable]
    public class StreamingAssetResouce : IResource
    {
        [SerializeField] string streamingAssetPath;

        public bool ReadAllowed()
        {
            return true;
        }

        public bool WriteAllowed()
        {
            return false;
        }

        public bool DeleteAllowed()
        {
            return false;
        }

        public string GetName()
        {
            return Path.GetFileName(streamingAssetPath);
        }

        public Stream OpenResourceForRead()
        {

            //WWW file = new WWW("jar:file://" + Application.dataPath + "!/assets/" + streamingAssetPath);

            WWW file = new WWW("file://" + Application.dataPath + "/StreamingAssets/" + streamingAssetPath);
            //WWW file = new WWW(Application.dataPath + "/" + streamingAssetPath);
            //WWW file = new WWW("jar:file://" + Application.dataPath + "!/assets/" + streamingAssetPath);
            var data = file.bytes;
            var length = data.LongLength;

            MemoryStream ms = new MemoryStream(file.bytes,0,data.Length);
            return ms;

        }

        public Stream OpenResourceForWrite()
        {
            throw new System.NotImplementedException();
        }

        public void DeleteResource()
        {
            throw new System.NotImplementedException();
        }
    }
}
