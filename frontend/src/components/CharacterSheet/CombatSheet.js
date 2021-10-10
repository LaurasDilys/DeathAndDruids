import { Button, TextField } from "@mui/material";
import { useEffect, useRef, useState } from "react";
import { useDispatch, useSelector } from "react-redux";
import { saveMonster } from "../../state/actions/creationThunk";
import { patchMonster } from "../../state/actions/monstersThunk";
import { monstersState } from "../../state/selectors";
import NameField from "./NameField";
import NumberField from "./NumberField";
import AbilityBlock from "./AbilityBlock";
import SkillBlock from "./SkillBlock";
import tree from '../../dictionaries/AbilityTree.json';
import OptionMenu from "./OptionMenu";
import Field from "./Field";

const CombatSheet = ({ monster, unmountMe, creation }) => {
  const dispatch = useDispatch();
  const amountRef = useRef();
  
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

  const handleHeal = () => {
    let heal = parseInt(amountRef.current.value, 10);
    
    if (heal > 0) {
      let currentHP = monster.currentHitPoints;
      let maxHP = monster.hitPoints;
      
      currentHP += heal;
      if (currentHP > maxHP) currentHP = maxHP;

      dispatch(patchMonster({
        name: "currentHitPoints",
        value: currentHP.toString()
      }));

      amountRef.current.value = 0;
    }
  }

  const handleDamage = () => {
    let damage = parseInt(amountRef.current.value, 10);

    if (damage > 0) {
      let temporary = monster.temporaryHitPoints;
      let current = monster.currentHitPoints;

      if (temporary > 0) { // damage takes away from temporary hit points first
        if (temporary >= damage) {
          temporary -= damage;
          dispatch(patchMonster({
            name: "temporaryHitPoints",
            value: temporary.toString()
          }));
        } else {
          damage -= temporary;
          temporary = 0;
          dispatch(patchMonster({
            name: "temporaryHitPoints",
            value: temporary.toString()
          }));
          current -= damage;
          dispatch(patchMonster({
            name: "currentHitPoints",
            value: current.toString()
          }));
        }
      } else {
        current -= damage;
        dispatch(patchMonster({
          name: "currentHitPoints",
          value: current.toString()
        }));
      }
      amountRef.current.value = 0;
    }
  }

  const handleSaveButtonValidation = (field, bool) => {

  }

  return(
    <div className="char-sheet-row">
      <div className="first-char-sheet-column">
        {/* <div className="name-field-div">
          <NameField
            disabled={!creation}
            nameRef={nameRef}
            name={"name"}
            value={valueOf("name")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div> */}
        <div>
          <div className="padding-top">
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
      </div>
      <div>
        <div className="triple">
          <NumberField
            disabled={!creation}
            name={"challengeRating"}
            value={valueOf("challengeRating")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            disabled
            name={"proficiencyBonus"}
            value={valueOf("proficiencyBonus")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <Field
            notRequired
            name={"alignment"}
            value={valueOf("alignment")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div>
          <div className="padding-top">
            {Object.keys(tree).slice(3, 6).map((ability, index) => <AbilityBlock
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
      </div>
      <div>
        <div className="triple">
          <NumberField
            disabled={!creation}
            name={"armorClass"}
            value={valueOf("armorClass")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            disabled={!creation}
            name={"speed"}
            value={valueOf("speed")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div className="triple">
          <NumberField
            name={"currentArmorClass"}
            value={valueOf("currentArmorClass")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            name={"currentSpeed"}
            value={valueOf("currentSpeed")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div className="triple padding-top">
          <NumberField
            name={"hitPoints"}
            value={valueOf("hitPoints")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            name={"currentHitPoints"}
            value={valueOf("currentHitPoints")}
            cannotBeSaved={handleSaveButtonValidation}
          />
          <NumberField
            name={"temporaryHitPoints"}
            value={valueOf("temporaryHitPoints")}
            cannotBeSaved={handleSaveButtonValidation}
          />
        </div>
        <div className="heal-damage">
          <div className="heal">
            <Button variant="contained" className="heal" onClick={handleHeal}>
              Heal
            </Button>
          </div>
          <div className="amount">
            <TextField
              label="Amount"
              type="number"
              inputRef={amountRef}
            />
          </div>
          <div className="damage">
            <Button variant="contained" className="damage" onClick={handleDamage}>
              Damage
            </Button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CombatSheet;