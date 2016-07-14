using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PowerSwitch.Entities;

namespace PowerSwitch.Data
{
    public class DataManager<TEntity> where TEntity : BaseEntity
    {
        private string filePath;
        private Collection<TEntity> data;

        public DataManager( )
        {
            CheckFilePath( );
        }

        private void CheckFilePath( )
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\");
            if (Directory.Exists(dir) == false)
                Directory.CreateDirectory(dir);

            filePath = Path.Combine(dir, typeof(TEntity).Name + ".dta");
        }

        /// <summary>
        /// Loads all the devices
        /// </summary>
        public void Load( )
        {
            if (File.Exists(filePath))
            {
                using (StreamReader rd = new StreamReader(filePath))
                {
                    data = JsonConvert.DeserializeObject<Collection<TEntity>>(rd.ReadToEnd( ));
                }
            }
            else
            {
                this.data = new Collection<TEntity>( );
            }
        }

        /// <summary>
        /// Fetch all configured devices
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> All( )
        {
            Load( );
            return data;
        }

        /// <summary>
        /// Remove the device 
        /// </summary>
        /// <param name="device"></param>
        public void Remove(TEntity entity)
        {
            Load( );

            TEntity inTheCollection = data.Where(p => p.Id == entity.Id).FirstOrDefault( );
            if (inTheCollection != null)
            {
                data.Remove(inTheCollection);
            }

            Save( );
        }

        /// <summary>
        /// Save or update a device
        /// </summary>
        /// <param name="device"></param>
        public void SaveOrUpdate(TEntity entity)
        {
            Load( );
            TEntity inTheCollection = data.Where(p => p.Id == entity.Id).FirstOrDefault( );
            if (inTheCollection != null)
            {
                int index = data.IndexOf(inTheCollection);
                data[index] = entity;
            }
            else
            {
                data.Add(entity);
            }

            Save( );
        }

        /// <summary>
        /// Save current devices to the disk
        /// </summary>
        public void Save( )
        {
            using (StreamWriter wr = new StreamWriter(File.Open(filePath, FileMode.Create, FileAccess.ReadWrite)))
            {
                wr.WriteLine(JsonConvert.SerializeObject(this.data));
            }
        }
    }
}
