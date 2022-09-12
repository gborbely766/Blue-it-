export default function Header(props) {
    
    
    return (
        <nav className="navbar navbar-expand-lg navbar-light bg-light">
            <div className="navbar-brand mx-5">
                <img src="./logo192.png" width={40} alt="Hello"></img>
            </div>
            <div className="collapse navbar-collapse" id="navbarSupportedContent">
                <ul className="navbar-nav mr-auto">
                    <li className="nav-item active my-1 mx-1">
                        <button className="btn btn-primary btn-sm">Home</button>
                    </li>
                    <li className="nav-item active my-1 mx-1">
                        <button className="btn btn-primary btn-sm">Contacts</button>
                    </li>
                    <li className="nav-item active my-1">
                        <button className="btn btn-primary btn-sm">Questions</button>
                    </li>

                    <li className="nav-item my-1">
                        <button className="btn btn-primary btn-sm" style={{ position: 'absolute', right: '0'}} onClick={props.handleClick}>Create Question</button>
                    </li>
                </ul>
                
            </div>
            
        </nav>
        
    )
}
