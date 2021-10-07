const AbilityBlock = props => {
  return(
    <>
      <h3>{props.name}</h3>
      {props.children}
    </>
  );
};

export default AbilityBlock;