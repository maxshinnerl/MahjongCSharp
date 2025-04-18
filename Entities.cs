// Entities.cs

namespace Mahjong
{
    public static class EntityManager
    {
        // EntityManager should be kept extremely lean, i.e. should just hold and return an integer.
        // You *can* maintain a list or HashSet of entities within this, but it is less efficient
        // Also you shouldn't have to mantain an active list like that since the component manager maintains the relevant details
        // But you can do it for debugging purposes if you want.
        private static int nextId = 0;
        public static int CreateEntity()
        {
            return nextId++;
        }
    }
}