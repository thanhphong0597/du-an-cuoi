import ExpandLess from "@mui/icons-material/ExpandLess";
import ExpandMore from "@mui/icons-material/ExpandMore";
import Collapse from "@mui/material/Collapse";
import List from "@mui/material/List";
import ListItem from "@mui/material/ListItem";
import ListItemButton from "@mui/material/ListItemButton";
import ListItemText from "@mui/material/ListItemText";
import ListSubheader from "@mui/material/ListSubheader";
import Typography from "@mui/material/Typography";
import * as React from "react";
import { colors } from "../../assets/data/colors";
import { sizes } from "../../assets/data/sizes";
import CheckboxLabels from "../../components/checkbox/CheckboxLabels";
import { useToggle } from "../../components/hooks/useToggle";

const BannerCategory = () => {
    const [color, handleColor] = useToggle();
    const [size, handleSize] = useToggle();

    return (
        <List
            sx={{
                border: "2px solid black",
                borderTop: "transparent",
                padding: "20px",
            }}
            component="nav"
            aria-labelledby="nested-list-subheader"
            subheader={
                <ListSubheader component="div" id="nested-list-subheader">
                    <Typography variant="h5" gutterBottom>
                        Bộ lọc:
                    </Typography>
                </ListSubheader>
            }
        >
            <div className="mau sac">
                <ListItemButton
                    onClick={handleColor}
                    sx={{ display: "flex", gap: "20px" }}
                >
                    <ListItemText
                        primary="Màu sắc"
                        sx={{ ml: "20px", whiteSpace: "nowrap" }}
                    />
                    {color ? <ExpandLess /> : <ExpandMore />}
                </ListItemButton>
                <Collapse in={color} timeout="auto" unmountOnExit>
                    {colors.map((color) => (
                        <ListItem
                            key={color.display}
                            component="div"
                            disablePadding
                        >
                            <ListItemButton sx={{ pl: 4 }}>
                                <CheckboxLabels item={color.display} />
                            </ListItemButton>
                        </ListItem>
                    ))}
                </Collapse>
            </div>
            <div className="kich thuoc">
                <ListItemButton
                    onClick={handleSize}
                    sx={{ display: "flex", gap: "20px" }}
                >
                    <ListItemText
                        primary="Kích thước"
                        sx={{ ml: "20px", whiteSpace: "nowrap" }}
                    />
                    {size ? <ExpandLess /> : <ExpandMore />}
                </ListItemButton>
                <Collapse in={size} timeout="auto" unmountOnExit>
                    {sizes.map((size, index) => (
                        <ListItem key={index} component="div" disablePadding>
                            <ListItemButton sx={{ pl: 4 }}>
                                <CheckboxLabels item={size.display} />
                            </ListItemButton>
                        </ListItem>
                    ))}
                </Collapse>
            </div>
        </List>
    );
};

export default BannerCategory;
