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
import tree from '../../dictionaries/AbilityTree.json';
import OptionMenu from "./OptionMenu";

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
    }
  }

  const handleSaveButtonValidation = (field, bool) => {
    if (bool) setCannotBeSaved([...cannotBeSaved, field]);
    else setCannotBeSaved(cannotBeSaved.filter(x => x !== field));
    // console.log(`${field} cannot be saved: ${bool}`);
  }

  return(
    <div>
      <OptionMenu onSave={handleSave} cannotBeSaved={cannotBeSaved} />
      <Button onClick={() => console.log(monster)}>Print Monster</Button>
      <h1>SourceId: {monster.sourceId}</h1>
      <Button disabled={cannotBeSaved.length > 0} onClick={handleSave}>Save</Button>
      {/* 
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
      /> */}
      <div>
        <div className="name-field-div">
          <NameField
            nameRef={nameRef}
            name={"name"}
            value={valueOf("name")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        {Object.keys(tree).slice(0, 3).map((ability, index) => <AbilityBlock
          key={index}
          name={ability}
          value={valueOf(ability)}
          modifierValue={valueOf(tree[ability]["modifier"])}
          cannotBeSaved={handleSaveButtonValidation}
        >
          {tree[ability]["skills"].map((skill, index) => <SkillBlock
            key={index}
            name={skill[0]}
            value={valueOf(skill[0])}
            proficiency={valueOf(skill[1])}
            proficiencyName={skill[1]}
          /> )}
        </AbilityBlock> )}
      </div>
    </div>
  );
};

export default CharacterSheet;