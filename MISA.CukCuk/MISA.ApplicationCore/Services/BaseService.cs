using MISA.ApplicationCore.Interfaces;
using MISA.ApplicationCore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.ApplicationCore.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        #region Declare
        IBaseRespository<TEntity> _baseRespository;
        #endregion

        #region Constructor
        public BaseService(IBaseRespository<TEntity> baseRespository)
        {
            _baseRespository = baseRespository;
        }
        #endregion

        public virtual int Add(TEntity entity)
        {
            var isValid = validate(entity) ;
            if (isValid == true)
            {
                return _baseRespository.Add(entity);
            }
            else
            {
                return 0;
            }
        }

        public int Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public TEntity GetEntityById(Guid entityId)
        {
            return _baseRespository.GetEntityById(entityId);
        }

        public IEnumerable<TEntity> GetEntities()
        {
            return _baseRespository.GetEntities();
        }

        public int Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        private Boolean validate(TEntity entity)
        {
            Boolean isValid = true;
            //Láy ra tất cả các thuộc tính public của entity
            var properties = entity.GetType().GetProperties();
            //Duyệt từng thuộc tính
            foreach(var property in properties)
            {
                //Check bắt buộc nhập
                if (property.IsDefined(typeof(Requirt), false))
                {
                    var propertyValue = property.GetValue(entity);
                    if (propertyValue == null)
                    {
                        isValid = false;
                        break;
                    }
                }
                //Check trùng mã
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    var propertyName = property.Name;
                    var propertyValue = property.GetValue(entity);
                    var res = _baseRespository.GetEntityBySpecs(propertyName, propertyValue);
                    if(res != null)
                    {
                        isValid = false;
                        break;
                    }
                }               
            }
            return isValid;
        }

    }
}
