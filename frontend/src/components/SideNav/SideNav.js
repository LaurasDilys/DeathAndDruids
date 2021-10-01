import { Button } from '@mui/material';
import { useEffect, useRef, useState } from 'react';
import { Link } from 'react-router-dom';
import './SideNav.css';

const SideNav = ({ routes }) => {
  const [visibility, setVisibility] = useState(true);
  const ref = useRef(null);

  const toggleSideBar = (event) => {
    // x is cursor's x-axis location
    const x = event.clientX;

    // yvh is the ratio between
    // cursor's y-axis location and viewport height
    const yvh = event.clientY / window.innerHeight;

    // css .side-nav { position: fixed;
    if (x <= 200 && // width: 200px;
      yvh > 0.3 &&  // top: 30vh;
      yvh <= 0.7)   // height: 40vh;
    {
    //   setVisibility(true);
    //   alert(ref.current.clientWidth);
    // } else {
    //   setVisibility(false);
    }
  };

  useEffect(() => {
    document.addEventListener("mousemove", toggleSideBar);
    return () => document.removeEventListener("mousemove", toggleSideBar);
  }, []);

  return (
    <nav ref={ref} className={visibility ? "side-nav visible" : "side-nav"}>
      <div className="nav-items">
        {routes.map(({ path, title }, index) =>
          <Link
            key={index}
            to={path}
            children={<Button>{title}</Button>}/>
        )}
      </div>
    </nav>
  );
};

export default SideNav;
