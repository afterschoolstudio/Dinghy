so instead of people doing ECS themselves, we provide 2D primitives that have underlying ECS representations

we can use the term "behaviors" or something for objects with functions
basically we puppet ECS on the backend and expose an API to users like AddTag() that internally adds some Tag component to something

"destorying" something for example could just be adding a Destroy component to an entity such that it is flagged to be destryoed at the end of the frame

Sprite (impliticlty animated)
Texture (non animated, has a frame)
Tilemap
Particle

but for internal updating and whatever we use ECS with components that map to states given via behaviors

https://www.reddit.com/r/gamedev/comments/apegca/comment/eg8brwk/?utm_source=reddit&utm_medium=web2x&context=3
![[Pasted image 20231005144749.png]]
![[Pasted image 20231005144819.png]]