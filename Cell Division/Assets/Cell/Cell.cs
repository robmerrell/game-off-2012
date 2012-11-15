using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

	// sprite representing the cell
	private OTSprite sprite;

	// Use this for initialization
	void Start () {
		// Texture atlas for the sprites
		OTSpriteAtlasCocos2D atlas = GameObject.Find("EntitiesAtlas").GetComponent<OTSpriteAtlasCocos2D>();

		sprite = OT.CreateObject(OTObjectType.Sprite).GetComponent<OTSprite>();
		sprite.spriteContainer = atlas;

		// transform
		sprite.transform.parent = transform;
		sprite.transform.position = new Vector2(0, 0);
		sprite.depth = -1;

		// for whatever reason instead of providing callbacks Orthello wants you to query the atlas to be ready,
		// so here we go...
		if (!atlas.isReady)
			StartCoroutine(WaitForAtlas(atlas));

		// Set the frame of the atlas
		int index = atlas.GetFrameIndex("blue_cell_large");
		sprite.frameIndex = index;
		sprite.size = atlas.GetFrame(index).size;
	}


	// Coroutine that waits for the atlas to be ready
	IEnumerator WaitForAtlas(OTSpriteAtlasCocos2D atlas) {
		yield return null;

		if (!atlas.isReady) {
			StartCoroutine(WaitForAtlas(atlas));			
		}
	}
}
