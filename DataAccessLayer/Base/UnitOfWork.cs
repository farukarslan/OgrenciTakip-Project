using Common.Message;
using DataAccessLayer.Interfaces;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;

namespace DataAccessLayer.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        #region Variables
        private readonly DbContext _context;
        #endregion
        public UnitOfWork(DbContext context)
        {
            if (context == null)
            {
                return;
            }
            else
            {
                _context = context;
            }
        }
        public IRepository<T> Rep => new Repository<T>(_context);

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                var sqlException = (SqlException)ex.InnerException?.InnerException;
                if (sqlException == null)
                {
                    Messages.HataMesaji(ex.Message);
                    return false;
                }
                else
                {
                    switch (sqlException.Number)
                    {
                        case 208:
                            Messages.HataMesaji("İşlem yapmak istediğiniz tablo veritabanında bulunamadı.");
                            break;
                        case 547:
                            Messages.HataMesaji("Seçilen kartın işlem görmüş hareketleri var, kart silinemez.");
                            break;
                        case 2601:
                        case 2627:
                            Messages.HataMesaji("Girmiş olduğunuz Id daha önce kullanılmıştır.");
                            break;
                        case 4060:
                            Messages.HataMesaji("İşlem yapmak istediğiniz veritabanı sunucuda bulunamadı.");
                            break;
                        case 18456:
                            Messages.HataMesaji("Sunucuya bağlanılmak istenilen kullanıcı adı ve parola hatalıdır.");
                            break;
                        default:
                            Messages.HataMesaji(sqlException.Message);
                            break;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;
            }

            return true;
        }

        #region Dispose
        private bool _disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposedValue = true;
            }
        }
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
