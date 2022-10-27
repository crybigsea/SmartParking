using SmartParking.Dtos.SysMenu;
using SmartParking.Dtos.SysUpdateInfo;
using SmartParking.Entitys;
using SmartParking.IAppServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace SmartParking.AppServices
{
    public class UpdateFileAppService : CrudAppService<SysUpdateFile, SysUpdateFileDto, Guid, SysUpdateFilePagedResultRequestDto>, IUpdateFileAppService
    {
        private IRepository<SysUpdateFile, Guid> _repository { get; set; }
        public UpdateFileAppService(IRepository<SysUpdateFile, Guid> repository) : base(repository)
        {
            _repository = repository;
        }

        protected override async Task<IQueryable<SysUpdateFile>> CreateFilteredQueryAsync(SysUpdateFilePagedResultRequestDto input)
        {
            var query = await base.CreateFilteredQueryAsync(input);

            return query.WhereIf(!input.Keyword.IsNullOrEmpty(), a => a.FileName.Contains(input.Keyword));
        }
    }
}
