using UnityEngine;
using System.Collections;

public class CellState : MonoBehaviour {

	// all possible states for a cell
	enum States {Small, Medium, Large};

	// current state of the cell
	private States currentState;

	// cell colors
	public enum CellColors {Blue, Red, Orange};	

	// the cell's color
	public CellColors cellColor {get; set;}

	// health
	private int health;

	// attack radius
	private int attackRadius;

	// state values
	public int largeMaxHealth = 100;
	public int mediumMaxHealth = 50;
	public int smallMaxHealth = 25;

	public int largeAttackRadius = 25;
	public int mediumAttackRadius = 15;
	public int smallAttackRadius = 7;


	void Start () {
		// start at the largest state
		ChangeState(States.Large);
	}


	// change the current state of the cell
	// A cell has 3 possible states while in play that directly influence the max health,
	// size and attack radius. All cells start at the large state (2) and progress down
	// to small (1) as they are divided.
	void ChangeState(States newState) {
		adjustHealthForState(newState);
		adjustAttackRadiusForState(newState);
		currentState = newState;

		// scale the cell
		if (currentState == States.Large) transform.localScale = new Vector3(1.0f, 1.0f, 0.0f);
		else if (currentState == States.Medium) transform.localScale = new Vector3(0.7f, 0.7f, 0.0f);
		else if (currentState == States.Small) transform.localScale = new Vector3(0.4f, 0.4f, 0.0f);
	}


	// change state either by moving one value down or one value up
	// in the state chain
	void ChangeStateDown() {
		if (currentState == States.Large) ChangeState(States.Medium);
		else if (currentState == States.Medium) ChangeState(States.Small);
	}
	void ChangeStateUp() {
		if (currentState == States.Small) ChangeState(States.Medium);
		else if (currentState == States.Medium) ChangeState(States.Large);
	}


	// adjust the health based on the maximum health of a cell state
	// If the health is lower than the maxiumum health then keep it.
	// Otherwise lower it.
	private void adjustHealthForState(States state) {
		int maxStateHealth = 0;
		if (state == States.Large) maxStateHealth = largeMaxHealth;
		else if (state == States.Medium) maxStateHealth = mediumMaxHealth;
		else if (state == States.Small) maxStateHealth = smallMaxHealth;

		if (health > maxStateHealth)
			health = maxStateHealth;
	}


	// adjust the attack radius for the cell state
	private void adjustAttackRadiusForState(States state) {
		if (state == States.Large) attackRadius = largeAttackRadius;
		else if (state == States.Medium) attackRadius = mediumAttackRadius;
		else if (state == States.Small) attackRadius = smallAttackRadius;
	}
}
