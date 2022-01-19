using Common.BaseModels;

namespace Common.ModelsDTO.Input
{
    public class GetUsersInputModel : BaseFiltrationModel
    {
        public Constants.UserState? State { get; set; }
    }
}
