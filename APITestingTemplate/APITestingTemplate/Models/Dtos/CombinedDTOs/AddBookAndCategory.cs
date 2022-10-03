using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APITestingTemplate.Models.Dtos;

namespace APITestingTemplate.Models.CombinedDTOs
{
    public class AddBookAndCategory
    {
        public ICollection<GetBookDto> BookData { get; set;  } = new List<GetBookDto>();

        public ICollection<GetBookCategoryDto> BookCategoryData { get; set; } = new List<GetBookCategoryDto>(); 

    }
}
