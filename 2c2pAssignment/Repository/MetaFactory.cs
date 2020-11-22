using _2c2pAssignment.DataAccess;
using _2c2pAssignment.Logger;
using _2c2pAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2c2pAssignment.Repository
{
    public class MetaFactory
    {
        private static MetaFactory metaFactory = null;
        public Dictionary<string, MetaFileType> _MetaFileDic = new Dictionary<string, MetaFileType>();
        private List<MetaValidation> _validation = new List<MetaValidation>();
        private MetaFactory()
        {
            LoadMetaData();
        }

        private void LoadMetaData()
        {
            try
            {
                _validation = DBAccess.LoadMetaDaata();

            }
            catch (Exception ex)
            {
                AppLogger.Log(ex);
            }
        }
        public Dictionary<string, List<MetaValidation>> GetValidation<T>()
        {
            Dictionary<string, List<MetaValidation>> metadata = new Dictionary<string, List<MetaValidation>>();
            try
            {
                var filterd = _validation.Where(x => x.TypeName == typeof(T).Name);
                foreach (MetaValidation md in filterd)
                {
                    if (!metadata.ContainsKey(md.DataSetName.ToLower()))
                    {
                        metadata.Add(md.DataSetName.ToLower(), new List<MetaValidation>() { md });
                    }
                    else
                        metadata[md.DataSetName.ToLower()].Add(md);
                }
            }
            catch (Exception ex)
            {

            }
            return metadata;
        }
        public static MetaFactory Instance
        {
            get
            {
                if (metaFactory == null)
                    metaFactory = new MetaFactory();
                return metaFactory;
            }
            set
            {

            }
        }
    }
}
