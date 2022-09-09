import React from "react";

export default function Header() {
    return (
        <nav class="navbar navbar-expand-lg navbar-light bg-light">
            <div class="navbar-brand mx-5">
                <img src="./logo192.png" width={40} alt="Hello"></img>
            </div>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
                <ul class="navbar-nav mr-auto">
                    <li class="nav-item active my-1 mx-1">
                        <button class="btn btn-primary btn-sm">Home</button>
                    </li>
                    <li class="nav-item active my-1 mx-1">
                        <button class="btn btn-primary btn-sm">Contacts</button>
                    </li>
                    <li class="nav-item active my-1">
                        <button class="btn btn-primary btn-sm">Questions</button>
                    </li>

                    <li class="nav-item my-1">
                        <button class="btn btn-primary btn-sm" style={{ position: 'absolute', right: '0'}}>Create Question</button>
                    </li>
                </ul>
            </div>
        </nav>
    )
}
