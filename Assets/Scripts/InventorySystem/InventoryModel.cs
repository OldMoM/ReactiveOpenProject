using UniRx;

namespace Peixi
{
    public class InventoryModel<T> 
    {
        public ReactiveCollection<T> set = new ReactiveCollection<T>();
    }
}
