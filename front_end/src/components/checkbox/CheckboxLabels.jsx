import Checkbox from "@mui/material/Checkbox";
import FormControlLabel from "@mui/material/FormControlLabel";
import FormGroup from "@mui/material/FormGroup";
import * as React from "react";

export default function CheckboxLabels({ onChange, checked, item }) {
    const inputRef = React.useRef(null);
    return (
        <FormGroup>
            <FormControlLabel
                key={item}
                control={<Checkbox />}
                label={item}
                inputRef={inputRef}
                className="capitalize whitespace-nowrap"
            />
        </FormGroup>
    );
}
