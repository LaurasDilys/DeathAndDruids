import { TextField } from "@mui/material";
import { withStyles } from "@mui/styles";
import { useEffect, useState } from "react"
import { useDispatch } from "react-redux";
import { patchCombatant } from "../../state/actions/combatThunk";
import { patchMonster } from "../../state/actions/monstersThunk";
import "./CharacterSheet.css"

const styles = {
  modifierStyle: {
    height: "2em",
    fontSize: "2em",
    textAlign: "center"
  }
};

const AbilityBlock = ({ id, name, value, modifierValue, cannotBeSaved, children, classes }) => {
  const [state, setState] = useState(value);
  const dispatch = useDispatch();

  useEffect(() => {
    if (state !== value) {
      setState(value);
    }
  }, [value])

  const handleChange = event => {
    if (event.target.value === "") {
      cannotBeSaved(name, true);
    } else {
      cannotBeSaved(name, false);
    }

    if (event.target.value > 99) {
      setState(30) // max ability score
    } else {
      setState(event.target.value);
    }

    if (id) {
      dispatch(patchCombatant({
        id: id,
        name: name,
        value: event.target.value
      }));
    } else {
      dispatch(patchMonster({
        name: name,
        value: event.target.value
      }));
    }
  }

  return(
    <div className="ability-block">
      <div className="ability">
        <TextField
          error={state === ""}
          label={name.charAt(0).toUpperCase() + name.slice(1)}
          value={state}
          type="number"
          // InputLabelProps={{
          //   shrink: true,
          // }}
          onChange={handleChange}
          inputProps={{style: { textAlign: "center" }}}
        />
        <TextField className="score"
          disabled
          value={modifierValue}
          InputProps={{ classes: { input: classes.modifierStyle } }}
        />
      </div>
      <div className="skills">
        {children}
      </div>
    </div>
  );
};

export default withStyles(styles)(AbilityBlock);;