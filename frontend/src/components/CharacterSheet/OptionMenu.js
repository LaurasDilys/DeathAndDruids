import { Button, FormControl, FormHelperText, Input, InputLabel, MenuItem, OutlinedInput, Select } from '@mui/material';
import { withStyles } from '@mui/styles';
import { useEffect, useRef, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { closeMonster, deleteOpenedMonster, newMonster, openMonster } from '../../state/actions/creationThunk';
import { creationState, monstersState } from '../../state/selectors/creationSelectors';
import './OptionMenu.css';
import { whiteVar } from '../../Themes';

const mouseEnteredOpt = (component, event) => {
  const width = component.clientWidth; // opt width
  const height = component.clientHeight; // opt height
  const x = event.clientX; // cursor's x-axis location
  const y = event.clientY; // cursor's y-axis location

  // opt is in the middle of viewport height, so
  // const margin is top and bottom opt margin
  const margin = (window.innerHeight - height) / 2
  const windowWidth = window.innerWidth;

  if (x > windowWidth - width &&
    y > margin &&
    y <= margin + height) return true;

  return false;
}

const styles = {
  select: {
    paddingLeft: 20,
    textAlign: "left",
    color: whiteVar
  }
};

const OptionMenu = ({ onSave, cannotBeSaved, unmountMe, classes }) => {
  const { monster: thisMonster } = useSelector(creationState);
  const { monsters } = useSelector(monstersState);
  const [selected, setSelected] = useState();
  const [visibility, setVisibility] = useState(false);
  const dispatch = useDispatch();
  const ref = useRef(null);

  const toggleOptionMenu = event => {
    if (mouseEnteredOpt(ref.current, event)) {
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
    if (thisMonster.saved) {
      return;
    }
    else if (thisMonster.sourceId == null) {
      confirm = window.confirm("This creation is unsaved. It will revert back to a new monster.");
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
      confirm = window.confirm("This creation is unsaved and will be permanently lost.");
    } else {
      confirm = window.confirm("Changes have not been saved. Are you sure you want to continue?");
    }
    confirm && dispatch(newMonster());
  }

  const handleOpen = event => {
    setSelected(event.target.value);
    let confirm;
    const id = monsters.find(x => x.name === event.target.value).id;
    if (thisMonster.saved) {
      dispatch(openMonster(id));
      return;
    }
    else if (thisMonster.sourceId == null) {
      confirm = window.confirm("This creation is unsaved and will be permanently lost.");
    } else {
      confirm = window.confirm("Changes have not been saved. Are you sure you want to continue?");
    }
    confirm && dispatch(openMonster(id));
  };

  const handleDelete = () => {
    if (thisMonster.sourceId !== null) {
      if (monsters.length === 1) unmountMe();
      window.confirm("Are you sure you want to delete this monster?")
      && dispatch(deleteOpenedMonster());
    }
  }

  const handleExit = () => {
    if (thisMonster.saved || window.confirm("Changes have not been saved. Are you sure you want to continue?")) {
      unmountMe();
      dispatch(closeMonster());
    }
  }
  
  return (
    <nav className={visibility ? "opt-viewport-height visible" : "opt-viewport-height"}>
      <div ref={ref} className="opt">
        <div className="opt-items">

          {(thisMonster.name !== "" && cannotBeSaved.length === 0 && !thisMonster.saved) &&
          <Button onClick={() => onSave()}>Save</Button>}

          {!thisMonster.saved &&
          <Button onClick={handleUndo}>Undo</Button>}

          <Button onClick={handleNew}>New</Button>

          {monsters.length > 0 &&
          <FormControl disabled={monsters.length === 0} sx={{ m: 1, width: "160px" }} error>
            <InputLabel>Open</InputLabel>
              <Select
                inputProps={{ classes: { select: classes.select } }}
                value={selected}
                label="Open"
                onChange={handleOpen}
              >
              {monsters.map(monster => <MenuItem key={monster.name} value={monster.name}>{monster.name}</MenuItem>)}
            </Select>
          </FormControl>}

          {thisMonster.sourceId !== null &&
          <Button disabled={thisMonster.sourceId === null} onClick={handleDelete}>Delete</Button>}
          
          <Button onClick={handleExit}>Exit</Button>
        </div>
      </div>
    </nav>
    // <nav className={visibility ? "opt-viewport-height visible" : "opt-viewport-height"}>
    //   <div ref={ref} className="opt">
    //     <div className="opt-items">
    //       <Button disabled={thisMonster.name === "" || cannotBeSaved.length > 0 || thisMonster.saved} onClick={() => onSave()}>Save</Button>
    //       <Button disabled={thisMonster.saved} onClick={handleUndo}>Undo</Button>
    //       <Button onClick={handleNew}>New</Button>
    //       <FormControl disabled={monsters.length === 0} sx={{ m: 1, width: "160px" }} error>
    //         <InputLabel>Open</InputLabel>
    //           <Select
    //             inputProps={{ classes: { select: classes.select } }}
    //             value={selected}
    //             label="Open"
    //             onChange={handleOpen}
    //           >
    //           {monsters.map(monster => <MenuItem key={monster.name} value={monster.name}>{monster.name}</MenuItem>)}
    //         </Select>
    //       </FormControl>
    //       <Button disabled={thisMonster.sourceId === null} onClick={handleDelete}>Delete</Button>
    //       <Button onClick={handleExit}>Exit</Button>
    //     </div>
    //   </div>
    // </nav>
  );
};

export default withStyles(styles)(OptionMenu);