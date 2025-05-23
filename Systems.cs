// Systems.cs

namespace Mahjong
{
    // NOTE: in Unity, deltaTime is calculated and provided as Time.deltaTime automatically
    // Here, it's hardcoded in Main to be 0.016

    public abstract class System(ComponentManager cm)
    {
        protected ComponentManager CM = cm;

        // abstract method means all subclasses MUST implement their own Update() method with 'override'
        public abstract void Update();

    }

    public class DisplayTileSystem(ComponentManager CM) : System(CM)
    {
        // Update should not take an entity ID, but a helper method can
        // Not sure if I even want to implement via a system but idk
        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}