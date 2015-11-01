using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {cell, mirror, sheets_0, lock_0, cell_mirror, sheets_1, lock_1, freedom};
	private States myState;

	// Use this for initialization
	void Start() {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update() {
		print(myState);
		if (myState == States.cell)					{ state_cell(); } 
		else if (myState == States.sheets_0) 		{ state_sheets_0();	}
		else if (myState == States.sheets_1)		{ state_sheets_1(); } 
		else if (myState == States.lock_0) 			{ state_lock_0(); }
		else if (myState == States.lock_1)			{ state_lock_1(); }
		else if (myState == States.mirror)			{ state_mirror(); }
		else if (myState == States.cell_mirror) 	{ state_cell_mirror(); }
		else if (myState == States.freedom) 		{ state_freedom(); } 
	}

	void state_cell() {
		text.text = "You are in a prison cell, and you want to escape. There are " +
					"some dirty sheets on the bed, a mirror on the wall, and the door " +
					"is locked from the outside.\n\n" +
					"Press (s) to view (s)heets, (m) to view (m)irror, (l) to view (l)ock.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;	
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
	}
	
	void state_mirror() {
		text.text = "The dirty old mirror on the wall seems loose.\n\n" +
					"Press (t) to (t)ake the mirror, or (r) to (r)eturn to roaming your cell";
		if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_cell_mirror() {
		text.text = "You are still in your cell, and you still want to escape. There are " +
					"some dirty sheets on the bed, a mark where the mirror was, " +
					"and the door which is still firmly locked.\n\n" +
					"Press (s) to view (s)heets, or (l) to view (l)ock";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}

	void state_sheets_0() {
		text.text = "You can't believe you sleep in these things. Surely it's " +
					"time somebody changed them. The pleasures of prison life " +
					"I guess!\n\n" +
					"Press (r) to (r)eturn to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		} 
	}

	void state_sheets_1() {
		text.text = "Holding a mirror in your hand doesn't make the sheets look " +
					"any better.\n\n" +
					"Press (r) to (r)eturn to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}
	
	void state_lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
					"combination is. You wish you could somehow see where the dirty " +
					"fingerprints were, maybe that would help.\n\n" +
					"Press (r) to (r)eturn to roaming your cell";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void state_lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
					"so you can see the lock. You can just make out fingerprints around " +
					"the buttons. You press the dirty buttons, and hear a click.\n\n" +
					"Press (o) to (o)pen, or (r) to (r)eturn to your cell";
		if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.freedom;
		} else if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void state_freedom() {
		text.text = "You are FREE!\n\n" +
					"Press (p) to (p)lay again";
		if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.cell;
		}
	}

}
