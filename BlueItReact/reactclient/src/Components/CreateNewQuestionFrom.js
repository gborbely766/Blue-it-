import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function CreateNewQuestionForm() {

    const initialFormData = Object.freeze({
        title: "Some title",
        message: "Some Message"
    })
    const[formData, setFormData] = useState(initialFormData)

    const handleChange = (e) => {
        setFormData ({
            ...formData,
            [e.target.name]: e.target.value
        })
    }

    const handleSubmit = (e) => {
        e.preventDefault();
        const questionToCreate = {
            id: 0,
            title: formData.title,
            image: formData.message
        }
    }
    const url = Constants.API

    return (
        <div>
            <form class="w-100 px-5">
                <h1 class="mt-5">Question</h1>
                <div class="mt-5">
                    <label class="h3 form-label">Title</label>
                    <input value={formData.title} name="title" type="text" class="form-control" onChange={handleChange}></input>
                </div>
                <div class="mt-4">
                    <label class="h3 form-label">Message</label>
                    <input value={formData.message} name="image" type="text" class="form-control" onChange={handleChange}></input>
                </div>
                <button onClick={handleSubmit} class="btn btn-primary btn-sm">Submit</button>
                <button onClick={() => props.OnQuestionCreated(null)} class="btn btn-primary btn-sm">Submit</button>
            </form>
        </div>
    )
}
