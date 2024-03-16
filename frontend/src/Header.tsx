import logo from './logo.png';

//creates the header
function Header(props: any) {
  return (
    <header className="row header navbar navbar-dark bg-dark">
      <div className="col-4">
        <img
          src={logo}
          alt="logo"
          className="logo"
          style={{ width: '400px' }}
        />
      </div>
      <div className="col subtitle">
        <h1 className="text-white">{props.title}</h1>
      </div>
    </header>
  );
}

export default Header;
