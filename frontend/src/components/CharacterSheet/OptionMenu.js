import { Button, FormControl, FormHelperText, InputLabel, MenuItem, OutlinedInput, Select } from '@mui/material';
import { useEffect, useRef, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { useLocation } from 'react-router-dom';
import { newMonster } from '../../state/actions/creationThunk';
import { openMonster } from '../../state/actions/monstersThunk';
import { creationState, monstersState } from '../../state/selectors/creationSelectors';
import './OptionMenu.css';

const mouseEnteredNav = (component, event) => {
  const width = component.clientWidth; // nav width
  const height = component.clientHeight; // nav height
  const x = event.clientX; // cursor's x-axis location
  const y = event.clientY; // cursor's y-axis location

  // nav is in the middle of viewport height, so
  // const margin is top and bottom nav margin
  const margin = (window.innerHeight - height) / 2
  const windowWidth = window.innerWidth;

  if (x > windowWidth - width &&
    y > margin &&
    y <= margin + height) return true;

  return false;
}

const OptionMenu = ({ onSave, cannotBeSaved }) => {
  const { monster: thisMonster } = useSelector(creationState);
  const { monsters } = useSelector(monstersState);
  const [selected, setSelected] = useState();
  const [visibility, setVisibility] = useState(false);
  const dispatch = useDispatch();
  const ref = useRef(null);

  const toggleOptionMenu = event => {
    if (mouseEnteredNav(ref.current, event)) {
      setVisibility(true);
    } else {
      setVisibility(false);
    }
  };

  useEffect(() => { // adds mouse move event listener for toggling SideNav
    document.addEventListener("mousemove", toggleOptionMenu);
    return () => document.removeEventListener("mousemove", toggleOptionMenu);
  }, []);

  const handleUndo = () => {
    let confirm;
    if (thisMonster.sourceId == null) {
      confirm = window.confirm("This creation is unsaved. Are you sure you want to revert back to new monster?");
      confirm && dispatch(newMonster());
    } else {
      confirm = window.confirm("Are you sure you want to undo the changes?");
      confirm && dispatch(openMonster(thisMonster.sourceId));
    }
  }

  const handleNew = () => {
    let confirm;
    if (thisMonster.saved) {
      dispatch(newMonster());
      return;
    }
    else if (thisMonster.sourceId == null) {
      confirm = window.confirm("This creation is unsaved. Are you sure you want to open a new one?");
    } else {
      confirm = window.confirm("Changes have not been saved. Are you sure you want to open a new monster?");
    }
    confirm && dispatch(newMonster());
  }

  const handleChange = (event) => {
    setSelected(event.target.value);
  };
  
  return (
    <nav className={visibility ? "opt-viewport-height visible" : "opt-viewport-height"}>
      <div ref={ref} className="opt">
        <div className="opt-items">
          <Button disabled={thisMonster.name === "" || cannotBeSaved.length > 0 || thisMonster.saved} onClick={() => onSave()}>Save</Button>
          <Button disabled={thisMonster.saved} onClick={handleUndo}>Undo</Button>
          <Button onClick={handleNew}>New</Button>
          <FormControl sx={{ m: 1, width: "160px" }} error>
            <InputLabel>Open</InputLabel>
              <Select
                value={selected}
                label="Open"
                onChange={handleChange}
              >
              {monsters.map(monster => <MenuItem key={monster.name} value={monster.name}>{monster.name}</MenuItem>)}
            </Select>
          </FormControl>
        </div>
      </div>
    </nav>
  );
};

export default OptionMenu;