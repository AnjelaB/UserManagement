using Common.BaseModels;
using System.Collections.Generic;

namespace Common.ModelsDTO.Output
{
    public class GetUsersOutput : BaseReportOutputModel
    {
        public List<UserModel> Users { get; set; }
    }
}
