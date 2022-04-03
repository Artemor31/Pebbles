using UnityEngine;

namespace Cards
{
    public class CardDecorator : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer _cover;
        [SerializeField] private SpriteRenderer _greenCover;
        [SerializeField] private SpriteRenderer _redCover;
        
        public CardDecorator SetRed(float alfa)
        {
            var color = _redCover.color;
            _redCover.color = new Color(color.r, color.g, color.b, alfa);
            return this;
        }

        public CardDecorator SetGreen(float alfa)
        {
            var color = _greenCover.color;
            _greenCover.color = new Color(color.r, color.g, color.b, alfa);
            return this;
        }

        public CardDecorator SetOpacity(float value)
        {
            _cover.color = new Color(1, 1, 1, value);
            return this;
        }

        public CardDecorator EnableCollider(bool on)
        {
            GetComponent<Collider>().enabled = on;
            return this;
        }

        public CardDecorator EnableAnimator(bool on)
        {
            GetComponent<Animator>().enabled = on;
            return this;
        }

        public CardDecorator Pop(int value, bool up)
        {
            var animator = GetComponent<Animator>();
            animator.enabled = true;
            animator.SetFloat("speed", up ? 1 : -1);
            animator.Play(value.ToString());
            return this;
        }
    }
}