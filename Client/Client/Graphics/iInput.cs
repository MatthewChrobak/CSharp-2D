namespace Client.Graphics
{
    interface iInput
    {
        void CheckKeys();
        void KeyPress(object arg1, object arg2);
        void KeyRelease(object arg1, object arg2);

        void MouseDown(object arg1, object arg2);
        void MouseUp(object arg1, object arg2);
        void MouseMove(object arg1, object arg2);
    }
}
