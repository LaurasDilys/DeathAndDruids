import { Button } from '@mui/material';
import { useEffect, useRef, useState } from 'react';
import { Link, useLocation } from 'react-router-dom';
import './SideNav.css';

const mouseEnteredNav = (component, event) => {
  const width = component.clientWidth; // nav width
  const height = component.clientHeight; // nav height
  const x = event.clientX; // cursor's x-axis location
  const y = event.clientY; // cursor's y-axis location

  // nav is in the middle of viewport height, so
  // const margin is top and bottom nav margin
  const margin = (window.innerHeight - height) / 2

  if (x <= width &&
    y > margin &&
    y <= margin + height) return true;

  return false;
}

const SideNav = ({ routes }) => {
  const [visibility, setVisibility] = useState(false);
  const ref = useRef(null);
  let location = useLocation();

  useEffect(() => { // sets document title
    document.title = "Death & Druids – " +
    routes.find(r => r.path === location.pathname).title
  }, [location]);

  const toggleSideNav = event => {
    if (mouseEnteredNav(ref.current, event)) {
      setVisibility(true);
    } else {
      setVisibility(false);
    }
  };

  useEffect(() => { // adds mouse move event listener for toggling SideNav
    document.addEventListener("mousemove", toggleSideNav);
    return () => document.removeEventListener("mousemove", toggleSideNav);
  }, []);

  return (
    <nav className={visibility ? "nav-viewport-height visible" : "nav-viewport-height"}>
      <div ref={ref} className="nav">
        <div className="nav-items">
          {routes.map(({ path, title }, index) =>
            <Link
              key={index}
              to={path}
              children={<Button variant="contained">{title}</Button>}/>
          )}
        </div>
      </div>
    </nav>
  );
};

export default SideNav;
