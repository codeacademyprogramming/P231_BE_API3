using ShopApp.Service.Dtos.BrandDtos;
using ShopApp.Service.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.Service.Interfaces
{
    public interface IBrandService
    {
        CreatedResultDto Create(BrandCreateDto createDto);
        void Edit(int id, BrandEditDto editDto);
        BrandGetDto GetById(int id);
        List<BrandGetAllItemDto> GetAll();
        void Remove(int id);
    }
}
