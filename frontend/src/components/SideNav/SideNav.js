import { Button } from '@mui/material';
import { useEffect, useRef, useState } from 'react';
import { Link } from 'react-router-dom';
import './SideNav.css';

const mouseEnteredNav = (component, event) => {
  const width = component.clientWidth; // nav width
  const height = component.clientHeight; // nav height
  const x = event.clientX; // cursor's x-axis location
  const y = event.clientY; // cursor's y-axis location

  // nav is in the middle of viewport height
  // const margin is top and bottom nav margin
  const margin = (window.innerHeight - height) / 2

  if (x <= width &&
    y >= margin &&
    y <= margin + height)
    return true;

  return false;
}

const SideNav = ({ routes }) => {
  const [visibility, setVisibility] = useState(true);
  const ref = useRef(null);

  const toggleSideBar = event => {
    if (mouseEnteredNav(ref.current, event)) {
      setVisibility(true);
    } else {
      setVisibility(false);
    }
  };

  useEffect(() => {
    document.addEventListener("mousemove", toggleSideBar);
    return () => document.removeEventListener("mousemove", toggleSideBar);
  }, []);

  return (
    <nav className={visibility ? "nav-viewport-height visible" : "nav-viewport-height"}>
      <div ref={ref} className="nav">
        <div className="nav-items">
          {routes.map(({ path, title }, index) =>
            <Link
              key={index}
              to={path}
              children={<Button>{title}</Button>}/>
          )}
        </div>
      </div>
    </nav>
  );
};

export default SideNav;
