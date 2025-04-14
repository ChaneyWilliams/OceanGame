using UnityEngine;
using System.Collections;

namespace Pathfinding
{
    /// <summary>
    /// Sets the destination of an AI to the position of a specified object.
    /// This component should be attached to a GameObject together with a movement script such as AIPath, RichAI or AILerp.
    /// This component will then make the AI move towards the <see cref="target"/> set on this component.
    ///
    /// See: <see cref="Pathfinding.IAstarAI.destination"/>
    ///
    /// [Open online documentation to see images]
    /// </summary>
    [UniqueComponent(tag = "ai.destination")]
    [HelpURL("http://arongranberg.com/astar/docs/class_pathfinding_1_1_a_i_destination_setter.php")]
    public class LeftFacingAIDesinationSetter : MonoBehaviour
{
        public Transform target;
        public Transform idlePos;
        public float aggroRange = 10f;
        IAstarAI ai;
        bool facingRight;
        SpriteRenderer spriteRenderer;
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
            // Update the destination right before searching for a path as well.
            // This is enough in theory, but this script will also update the destination every
            // frame as the destination is used for debugging and may be used for other things by other
            // scripts as well. So it makes sense that it is up to date every frame.
            if (ai != null) ai.onSearchPath += Update;
        }

        void OnDisable()
        {
            if (ai != null) ai.onSearchPath -= Update;
        }

        /// <summary>Updates the AI's destination every frame</summary>
        void Update()
        {
            if (target != null && ai != null)
            {
                if (Vector3.Distance(target.position, idlePos.position) > aggroRange)
                {
                    ai.destination = idlePos.position;
                }
                else
                {
                    ai.destination = target.position;
                }
            }
            Flip();
        }
        private void Flip()
        {
            if (ai.velocity.x <= 0 && facingRight)
            {
                facingRight = !facingRight;
                Vector3 theScale = gameObject.transform.localScale;
                theScale.x *= -1;
                gameObject.transform.localScale = theScale;
            }
            else if (ai.velocity.x > 0 && !facingRight)
            {
                facingRight = !facingRight;
                Vector3 theScale = gameObject.transform.localScale;
                theScale.x *= -1;
                gameObject.transform.localScale = theScale;
            }

        }
    }
}
