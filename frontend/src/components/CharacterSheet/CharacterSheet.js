import { Button } from "@mui/material";
import { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { getOpenedMonster, saveMonster } from "../../state/actions/creationThunk";
import { getMonsters } from "../../state/actions/monstersThunk";
import { monstersState } from "../../state/selectors/creationSelectors";
import CheckBox from "./CheckBox";
import NameField from "./NameField";
import NumberField from "./NumberField";
import AbilityBlock from "./AbilityBlock";
import SkillBlock from "./SkillBlock";
import tree from '../Dictionaries/AbilityTree.json';

const CharacterSheet = ({ monster }) => {
  const [cannotBeSaved, setCannotBeSaved] = useState([]);
  const { monsters } = useSelector(monstersState);
  const dispatch = useDispatch();
  const nameRef = useRef();

  useEffect(() => { // on first render or page refresh
    const name = nameRef.current.value;
    if (name === "" ||
      monsters.filter(f => f.id !== monster.sourceId).map(m => m.name).includes(name))
    {
      setCannotBeSaved([...cannotBeSaved, "name"]);
    }
  }, []);
  
  const mapped = obj => {
    let array = [];
    let keys = Object.keys(obj);
    let values = Object.values(obj);

    for (let i = 0; i < keys.length; i++) {
      const monsterPropertyAsNameAndValue = {
        name : keys[i],
        value : values[i]
      }
      array.push(monsterPropertyAsNameAndValue)
    }
    return array;
  }

  const valueOf = name => {
    return mapped(monster).find(x => x.name === name).value;
  }

  const handleSave = () => {
    if (monster.saved) {
      alert("No changes have been made");
    }
    else {
      dispatch(saveMonster());
      dispatch(getOpenedMonster());
      // update this monster with its sourceId and updated "saved" property
      // ISSUE: dispatch(getOpenedMonster()) takes too long to resolve
      // sourceId and "saved" property don't get updated quickly enough
      dispatch(getMonsters());
    }
  }

  const handleSaveButtonValidation = (field, bool) => {
    if (bool) setCannotBeSaved([...cannotBeSaved, field]);
    else setCannotBeSaved(cannotBeSaved.filter(x => x !== field));
    // console.log(`${field} cannot be saved: ${bool}`);
  }

  return(
    <div>
      <Button disabled={cannotBeSaved.length > 0} onClick={handleSave}>Save</Button>
      <h1>SourceId: {monster.sourceId !== null ? monster.sourceId : 0}</h1>
      <h2>Name: {monster.name}</h2>
      <NameField
        nameRef={nameRef}
        name={"name"}
        value={valueOf("name")}
        cannotBeSaved={handleSaveButtonValidation}
      />
      <h2>Initiative: {monster.initiative}</h2>
      <NumberField
        name={"initiative"}
        value={valueOf("initiative")}
        cannotBeSaved={handleSaveButtonValidation}
      />
      <div>
        {Object.keys(tree).map((ability, index) => <AbilityBlock key={index} name={ability}>
          {tree[ability].map((skill, index) => <SkillBlock key={index} name={skill} /> )}
        </AbilityBlock> )}
      </div>
    </div>
  );
};

export default CharacterSheet;